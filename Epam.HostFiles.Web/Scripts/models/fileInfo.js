$(function () {
    appHostFiles.FileInfo = Backbone.Model.extend();
    appHostFiles.FileInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.FileInfo
    });
})