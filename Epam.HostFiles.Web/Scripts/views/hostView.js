$(function () {
    appHostFiles.HostPageView = Backbone.View.extend({
        events:{
            "click " : ''
        },
        render: function (drive, path) {
            appHostFiles.directoryCollection = new appHostFiles.DirectoryInfoCollection();
            appHostFiles.fileCollection = new appHostFiles.FileInfoCollection();
            appHostFiles.fileCollection.url = "/api/files/" + drive + ":/" + path;
            appHostFiles.directoryCollection.url = "/api/dirs/" + drive + ":/" + path;
            appHostFiles.directoryCollection.fetch({
                success: function (dirs) {
                    appHostFiles.fileCollection.fetch({
                        success: function (files) {
                            appHostFiles.utility.renderTemplate('hostPage.html', $("#content"), { dirs: dirs, files: files });
                        }
                    });
                }
            });
        }
    })
})