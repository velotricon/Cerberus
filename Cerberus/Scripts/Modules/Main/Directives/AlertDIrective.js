function AlertDirective() {
    return {
        restrict: 'E',
        templateUrl: 'Template/Alert',
        replace: true,
        scope: {
            title: '@',
            message: '@',
            alertTitle: '@'
        },//end-of_scope
        link: AlertLinkFunction,
        controller: AlertController
    }//end-of-return
}//end-fo-AlertDirective

function AlertLinkFunction(scope, element, attr, ctrl, transcludeFn) {

}

function AlertController($scope, $element, $attrs, $transclude) {
    alert($scope.alertTitle);

    $scope.CloseAlert_Click = function () {
        var v_scope = $scope; //diagnostics only (should by hidden after tests)
        var v_element = $element; //diagnostics only (should by hidden after tests)
        //$scope.$parent.IsDoubled = false
        //To nie jest zbyt dobre ukrywanie bo tak naprawdę jeśli kod ma być używany ponownie to nie mogę wiedzieć czy za
        //pokazywanie albo ukrywanie alerta będzie odpowiedzialne IsDoubled, IsError albo IsDupa. Muszę jakoś inaczej
        //dojść do tego jaka zamienna jest odpowiedzialna za pokazywanie alerta
        //v_element.attr('ng-show')
        //v_scope.$parent["IsDoubled"] = false
        $scope.$parent[$element.attr('ng-show')] = false;
    }
}