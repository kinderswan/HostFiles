$(function () {
    appHostFiles.HostPageView = Backbone.View.extend({
        drive: '',
        path: '',
        events: {
            "submit #file-upload": "uploadFile",
            "submit #dir-add": "addDirectory",
            "click #parent-dir": "navigateToParent"
        },
        render: function (drive, path, registeredUser) {
            var regUser = registeredUser;            
            var self = this;
            this.drive = drive;
            this.path = path === null ? "" : path;

            appHostFiles.utility.renderTemplate('userLi.html', $("#user-nav"), {
                user: regUser
            });

            appHostFiles.directoryCollection = new appHostFiles.DirectoryInfoCollection();
            appHostFiles.fileCollection = new appHostFiles.FileInfoCollection();
            
            appHostFiles.fileCollection.url = "/api/files/" + this.drive + ":/" + this.path;
            appHostFiles.directoryCollection.url = "/api/dirs/" + this.drive + ":/" + this.path;
            var rootDir = this.drive + ":/" + this.path;
            appHostFiles.directoryCollection.fetch({
                success: function (dirs) {
                    appHostFiles.fileCollection.fetch({
                        success: function (files) {
                            appHostFiles.utility.renderTemplate('hostPage.html', $("#content"), {
                                dirs: dirs,
                                files: files,
                                parentDir: rootDir,
                                user: regUser
                            });                            
                        }
                    });
                }
            });
        },
        uploadFile: function (e) {
            e.preventDefault();
            var rootDir = this.drive + ":/" + this.path;
            var self = this;
            var formData = new FormData($("#file-upload")[0]);
            $.ajax({
                url: "api/files/" + rootDir.replace(/\\/g, ' / '),
                type: "POST",
                data: formData,
                success: function (data) {
                    if (data) {
                        self.renderSuccessFile(data, rootDir);
                    }
                },
                error: function (data) {
                    if (data.status == 409) {
                        alert(JSON.parse(data.responseText).Message);
                    }
                    else {
                        alert("You have no permissions to upload new files!");
                    }
                },
                cache: false,
                contentType: false,
                processData: false
            });
        },
        addDirectory: function (e) {
            e.preventDefault();
            var self = this;
            var rootDir = this.drive + ":/" + this.path;
            var formData = new FormData($("#dir-add")[0]);
            $.ajax({
                url: "api/dirs/" + rootDir.replace(/\\/g, ' / '),
                type: "POST",
                data: formData,
                success: function (data) {
                    if (data) {
                        self.renderSuccessDir(data, rootDir);
                    }
                    else {
                        alert("Creating directory that already exists!");
                    }
                },
                error: function () {
                    alert("You have no permissions to add new directories!");
                },
                cache: false,
                contentType: false,
                processData: false
            });

        },
        renderSuccessFile: function (data, rootDir) {
            appHostFiles.fileCollection.add(new appHostFiles.FileInfo({
                FileName: data.FileName,
                Path: data.Path,
                Size: data.Size
            }));
            $("#content").empty();
            appHostFiles.utility.renderTemplate('hostPage.html', $("#content"), {
                dirs: appHostFiles.directoryCollection,
                files: appHostFiles.fileCollection,
                parentDir: rootDir
            });
        },

        renderSuccessDir: function (data, rootDir) {
            appHostFiles.directoryCollection.add(new appHostFiles.DirectoryInfo({
                DirectoryName: data.DirectoryName,
            }));
            $("#content").empty();
            appHostFiles.utility.renderTemplate('hostPage.html', $("#content"), {
                dirs: appHostFiles.directoryCollection,
                files: appHostFiles.fileCollection,
                parentDir: rootDir
            });
        },

        navigateToParent: function (e) {
            if (this.path === "") {
                e.preventDefault();
                appHostFiles.App.navigate("files", true);
            }

        }

    })
})