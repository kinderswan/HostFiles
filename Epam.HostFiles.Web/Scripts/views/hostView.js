$(function () {
    appHostFiles.HostPageView = Backbone.View.extend({
        drive: '',
        path: '',
        parentDir: '',
        el: $("#content"),
        events: {
            "submit #file-upload": "uploadFile"
        },
        render: function (drive, path) {
            this.drive = drive;
            this.path = path === null ? "" : path;
            appHostFiles.directoryCollection = new appHostFiles.DirectoryInfoCollection();
            appHostFiles.fileCollection = new appHostFiles.FileInfoCollection();

            appHostFiles.fileCollection.url = "/api/files/" + this.drive + ":/" + this.path;
            appHostFiles.directoryCollection.url = "/api/dirs/" + this.drive + ":/" + this.path;
            this.renderData();
        },
        renderData: function () {
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
            e.ajaxSuccess(function () {
                appHostFiles.fileCollection.add(new appHostFiles.FileInfo({
                    fileName: e.target[0].files[0].name,
                    path: (this.drive.toUpperCase() + ":\\" + this.path.replace(/\\/g, '/') + "\\" + e.target[0].files[0].name),
                    size: e.target[0].files[0].size
                }));
                $("#content").empty();
                var rootDir = this.drive + ":/" + this.path;
                appHostFiles.utility.renderTemplate('hostPage.html', $("#content"), {
                    dirs: appHostFiles.directoryCollection,
                    files: appHostFiles.fileCollection,
                    parentDir: rootDir
                });
            });

        }
    })
})