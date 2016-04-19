$(function () {
    appHostFiles.FileInfo = Backbone.Model.extend({
        defaults: {
            fileName: '',
            path: '',
            size: ''
        }
    });
    appHostFiles.FileInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.FileInfo,
        url: ''
    });
})