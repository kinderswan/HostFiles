//test('Example test', function () {
//    equal(1, 1, 'One is one');
//})
//asyncTest('Ajax tests', function () {
//    expect(1); // we have one async test to run

//    var xhr = $.ajax({
//        type: 'GET',
//        url: 'test-response.html'
//    })
//	.always(function (data, status) {
//	    var $data = $(data);
//	    var pageTitle = $data.filter('title').text();
//	    equal(pageTitle, 'Test Page', 'Title of test-response.html should be \'Test Page\'');
//	    start(); // we have our answer for this assertion, continue testing other assertions
//	});

//});

asyncTest('Test successfull login', function () {
    expect(1); // we have one async test to run
    $.ajax({
        url: "/api/logout",
        type: "POST"
    }).success(function () {
        $.ajax({
            url: "/api/login",
            data: JSON.stringify({
                Login: "test",
                Password: "test"
            }),
            type: "POST",
            datatype: 'json',
            contentType: 'application/json'
        }).success(function () {
            var xhr = $.ajax({
                type: 'GET',
                url: '/api/registeredUser'
            })
        .always(function (data, status) {
            start();
            equal(data.Name, "test", "Get logged user");
        });
        });

    })


});
asyncTest('Test get drives', function () {
    expect(1); // we have one async test to run
    $.ajax({
        url: "/api/logout",
        type: "POST"
    }).success(function () {
        $.ajax({
            url: "/api/login",
            data: JSON.stringify({
                Login: "test",
                Password: "test"
            }),
            type: "POST",
            datatype: 'json',
            contentType: 'application/json'
        }).success(function () {
            var xhr = $.ajax({
                type: 'GET',
                url: '/api/drives'
            })
        .always(function (data, status) {
            start();
            equal(data[0].DriveName, "C:\\", "Get drive C:\\");
        });
        });
    })
});
asyncTest('Test get files', function () {
    expect(1); // we have one async test to run
    $.ajax({
        url: "/api/logout",
        type: "POST"
    }).success(function () {
        $.ajax({
            url: "/api/login",
            data: JSON.stringify({
                Login: "test",
                Password: "test"
            }),
            type: "POST",
            datatype: 'json',
            contentType: 'application/json'
        }).success(function () {
            var xhr = $.ajax({
                type: 'GET',
                url: '/api/files/C:'
            })
        .always(function (data, status) {
            start();
            equal(data.length!==0,true, "There are some files at drive C");
        });
        });
    })
});
asyncTest('Main page title test', function () {
    expect(1); // we have one async test to run
    $.ajax({
        url: "/api/logout",
        type: "POST"
    }).success(function () {
        $.ajax({
            url: "/api/login",
            data: JSON.stringify({
                Login: "test",
                Password: "test"
            }),
            type: "POST",
            datatype: 'json',
            contentType: 'application/json'
        }).success(function () {
            var xhr = $.ajax({
                type: 'GET',
                url: '/'
            }).always(function (data, status) {
                var $data = $(data);
                var pageTitle = $data.filter('title').text();
                equal(pageTitle, 'Host files', 'Title of / should be \'Host files\'');
                start(); // we have our answer for this assertion, continue testing other assertions
            });
        });
    })
});


asyncTest('Main page name test', function () {
    expect(1); // we have one async test to run
    $.ajax({
        url: "/api/logout",
        type: "POST"
    }).success(function () {
        $.ajax({
            url: "/api/login",
            data: JSON.stringify({
                Login: "test",
                Password: "test"
            }),
            type: "POST",
            datatype: 'json',
            contentType: 'application/json'
        }).success(function () {
            var xhr = $.ajax({
                type: 'GET',
                url: '../../Templates/drivePage.html'
            }).always(function (data, status) {
                console.log(data);
                var pageTitle = $('h2',data).text();
                equal(pageTitle, 'Select drive', 'Title should be \'Select drive\'');
                start(); // we have our answer for this assertion, continue testing other assertions
            });
        });
    })
});

