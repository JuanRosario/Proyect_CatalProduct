var app = angular.module("Homeapp", []);



app.controller("HomeController", function ($scope, $http) {

    $scope.btntext = "Save";

    // Add record

    $scope.savedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Home/Add_record',

            data: $scope.register

        }).then(function (response) {

            $scope.btntext = "Save";

            $scope.register = null;

            alert(response.data);

        }).error(function () {

            alert('Failed');

        });

    };

    app.controller('MainCtrl', function ($scope, $http){
        $http({
            method: 'GET',
            url: 'api/url-api'
        }).then(function (response){

        },function (error){

        });
    });
    // Display all record

    $http.get("/Home/Get_data").then(function (d) {

        $scope.record = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display record by id

    $scope.loadrecord = function (id) {

        $http.get("/Home/Get_databyid?id=" + id).then(function (d) {

            $scope.register = d.data[0];

        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleterecord = function (id) {

        $http.get("/Home/delete_record?id=" + id).then(function (d) {

            alert(d.data);

            $http.get("/Home/Get_data").then(function (d) {

                $scope.record = d.data;

            }, function (error) {

                alert('Failed');

            });

        }, function (error) {

            alert('Failed');

        });

    };

    // Update record

    $scope.updatedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Home/update_record',

            data: $scope.register

        }).then(function (d) {

            $scope.btntext = "Update";

            $scope.register = null;

            alert(d.data);

        }).error(function () {

            alert('Failed');

        });

    };

});