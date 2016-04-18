$(function () {
    appHostFiles.UserInfo = Backbone.Model.Extend({
        defaults: {
            name: '',
            login: '',
            password: '',
            role: 'anonymous'
        }
    })

    appHostFiles.UserInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.UserInfo,
        url: 'api/users'
    })
})