angular.module('TweetApp', [])
    .controller('TweetCtrl', function ($scope, $http) {
        $scope.submitTweet = function () {
            $http.post("api/Tweet?tweet=" + $scope.txtTweet)
                .then(function (response) {
                    $scope.modalTitle = "Tweet Result";
                    $scope.modalBody = response.data;
                    $('#modalResult').modal();
                }
                , function (error) {
                    $scope.modalTitle = "Error";
                    $scope.modalBody = response.data;
                    $('#modalResult').modal();
                });
        }

    });