﻿(function (mod) {
    mod.buildTemplateUrl = function (templateFileName) {
        return "/Templates/" + templateFileName;
    };

    mod.renderTemplate = function (templateFileName, $el, data) {
        datum = data || {};
        mod.getHtmlFromTemplate(templateFileName, function (html) {
            var result = _.template(html);
            $el.empty().append(result(datum));
        });
    };

    mod.getHtmlFromTemplate = function (templateFileName, callback) {
        $.get(mod.buildTemplateUrl(templateFileName), function (template) {
            callback(template);
        });
    };

    mod.serializeObject = function (selector) {
        var result = {};
        var serializedArray = $(selector).serializeArray({ checkboxesAsBools: true });
        $.each(serializedArray, function () {
            if (result[this.name]) {
                if (!result[this.name].push) {
                    result[this.name] = [result[this.name]];
                }
                result[this.name].push(this.value || "");
            } else {
                result[this.name] = this.value || "";
            }
        });
        return result;
    };

    mod.getBaseUrl = function () {
        var pathArray = window.location.href.split('/');
        var baseUrl = pathArray[0] + "//" + pathArray[1] + pathArray[2];
        if (baseUrl.substr(baseUrl.length - 1) !== "/") {
            baseUrl += "/";
        };
        return baseUrl;
    };

})(window.appHostFiles.utility = window.appHostFiles.utility || {}, jQuery);