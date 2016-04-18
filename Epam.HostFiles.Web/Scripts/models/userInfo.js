$(function () {
    appHostFiles.UserInfo = Backbone.Model.extend({
        defaults: {
            name: '',
            login: '',
            password: '',
            role: 'anonymous'
        }
    });

    appHostFiles.UserInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.UserInfo,
        url: 'api/users'
    });
})