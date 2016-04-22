$(function () {
    appHostFiles.HostPageView = Backbone.View.extend({
        drive: '',
        path: '',
        events: {
            "submit #file-upload": "uploadFile",
            "submit #dir-add": "addDirectory",
            "click #parent-dir": "navigateToParent"
        },
        render: function (drive, path) {
            this.drive = drive;
            this.path = path === null ? "" : path;
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
                                parentDir: rootDir
                            });
                        }
                    });
                }
            });
        },
        uploadFile: function (e) {
            e.preventDefault();
            var rootDir = this.drive + ":/" + this.path;
            var formData = new FormData($("#file-upload")[0]);
            $.ajax({
                url: "api/files/" + rootDir.replace(/\\/g, ' / '),
                type: "POST",
                success: this.renderSuccessFile(e, rootDir),
                error: function () {
                    alert(this.url + "error");
                },
                data: formData,
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
                        self.renderSuccessDir(e, rootDir);
                    }
                    else {
                        alert("Creating directory that already exists!");
                    }
                },
                error: function () {
                    console.log(this.url + "error");
                },
                cache: false,
                contentType: false,
                processData: false
            });

        },
        renderSuccessFile: function (e, rootDir) {
            appHostFiles.fileCollection.add(new appHostFiles.FileInfo({
                fileName: e.target[0].files[0].name,
                path: (rootDir.replace(/\\/g, '/') + "\\" + e.target[0].files[0].name),
                size: e.target[0].files[0].size
            }));
            $("#content").empty();
            appHostFiles.utility.renderTemplate('hostPage.html', $("#content"), {
                dirs: appHostFiles.directoryCollection,
                files: appHostFiles.fileCollection,
                parentDir: rootDir
            });
        },

        renderSuccessDir: function (e, rootDir) {
            console.log(rootDir);
            console.log(e.target[0].value);
            appHostFiles.directoryCollection.add(new appHostFiles.DirectoryInfo({
                directoryName: rootDir +"\\"+ e.target[0].value,
            }));
            $("#content").empty();
            var self = this;
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