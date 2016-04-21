$(function () {
    appHostFiles.DrivePageView = Backbone.View.extend({
        drive: '',
        events: {
        },
        render: function () {
            appHostFiles.drivesCollection = new appHostFiles.DriveInfoCollection();
            appHostFiles.drivesCollection.fetch({
                success: function (drives) {
                    appHostFiles.utility.renderTemplate('drivePage.html', $("#content"), {
                        drives: drives
                    });
                }
            })
        }

    })
})