angular.module('TweetApp', [])
    .controller('TweetCtrl', function ($scope, $http) {
        $scope.answered = false;

        $scope.answer = function () {
            alert('Hi');
        };
    });