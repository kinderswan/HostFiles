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

            setTimeout(function () {
                appHostFiles.drivesCollection.fetch({
                    success: function (drives) {
                        appHostFiles.utility.renderTemplate('drivePage.html', $("#content"), {
                            drives: drives
                        });
                    }
                })
            }, 10);
        }

    })
})