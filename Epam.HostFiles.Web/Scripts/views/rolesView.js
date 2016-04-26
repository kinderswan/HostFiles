$(function () {
    appHostFiles.RolesPageView = Backbone.View.extend({
        events: {
            "click #update-role-button": "updateUserRole",
            "click #add-role-button": "addUserRole"
        },
        render: function (id) {
            appHostFiles.rolesCollection = new appHostFiles.RoleInfoCollection();
            if (id !== null) {
                appHostFiles.rolesCollection.url = "api/roles/" + id;
            }
            appHostFiles.rolesCollection.fetch({
                success: function (roles) {
                    appHostFiles.utility.renderTemplate("manageRolesPage.html", $("#content"), {
                        roles: roles
                    })
                }
            })
        },
        updateUserRole: function (e) {
            e.preventDefault();
            var roleModel = appHostFiles.rolesCollection.where({ Role: e.target.form[1].value })
            roleModel[0].attributes.RoleDescription = e.target.form[2].value;
            $.ajax({
                url: "api/roles/" + roleModel[0].attributes.UserRoleId,
                type: "PUT",
                success: function (data) {
                    console.log(data);
                },
                error: function (data) {
                    console.log(data);
                },
                data: JSON.stringify(roleModel[0].attributes),
                cache: false,
                contentType: 'application/json; charset=utf-8',
                processData: false
            });
        },
        addUserRole: function (e) {
            e.preventDefault();
            var formData = appHostFiles.utility.serializeObject($('#add-role'));
            var self = this;
            $.ajax({
                url: "api/roles/",
                type: "POST",
                data: JSON.stringify(formData),
                success: function (data) {
                    if (data) {
                        self.renderSuccessData(data);
                    }
                    else {
                        alert("Role hasn't been added during to some mistakes");
                    }
                },
                error: function (data) {
                    if (data.status == 409) {
                        alert(JSON.parse(data.responseText).Message);
                    }
                },
                cache: false,
                contentType: 'application/json; charset=utf-8',
                processData: false
            });
        },
        renderSuccessData: function(data){
            appHostFiles.rolesCollection.add(new appHostFiles.RoleInfo({
                UserRoleId: data.UserRoleId,
                Role: data.Role,
                RoleDescription: data.RoleDescription
            }));
            $("#content").empty();
            appHostFiles.utility.renderTemplate('manageRolesPage.html', $("#content"), {
                roles: appHostFiles.rolesCollection
            });
        }

    })
})