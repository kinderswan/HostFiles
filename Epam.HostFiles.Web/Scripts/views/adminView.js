$(function () {
    appHostFiles.AdminPageView = Backbone.View.extend({
        events: {
        },
        registeredUser:'',
        render: function (user) {
            this.registeredUser = user;
            var self = this;
            $("#user-nav").empty();
            appHostFiles.utility.renderTemplate('userLi.html', $("#user-nav"), {
                user: self.registeredUser
            });

            setTimeout(function () {
                appHostFiles.utility.renderTemplate('adminPage.html', $("#content"));
            }, 10);
        }
    })
})