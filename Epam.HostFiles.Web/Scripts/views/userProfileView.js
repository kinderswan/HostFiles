$(function () {
    appHostFiles.UserProfilePageView = Backbone.View.extend({
        events: {
        },
        render: function (data) {
            appHostFiles.utility.renderTemplate("userProfilePage.html", $(this.el), {
                user: data
            });
        },
    })
})