$(function () {
    appHostFiles.IndexPageView = Backbone.View.extend({
        events: {
        },
        render: function () {
            appHostFiles.utility.renderTemplate("indexPage.html", $(this.el));
        },
    })
})