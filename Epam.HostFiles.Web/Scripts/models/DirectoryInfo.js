$(function () {
    appHostFiles.DirectoryInfo = Backbone.Model.extend();
    appHostFiles.DirectoryInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.DirectoryInfo
    });
})