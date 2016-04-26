$(function () {
    appHostFiles.DrivePageView = Backbone.View.extend({
        events: {
        },
        render: function (data) {
            $("#user-nav").empty();
            appHostFiles.utility.renderTemplate('userLi.html', $("#user-nav"), {
                user: data
            });
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