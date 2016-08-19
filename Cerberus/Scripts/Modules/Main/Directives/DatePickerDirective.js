function DatePickerDirective() {
    return {
        restrict: 'E',
        templateUrl: 'Template/DatePicker',
        replace: true,
        link: DatePickerLinkFunction,
        controller: DatePickerController,
        scope: {
            model: '='
        }
    }//end-of-return
}//end-of-DatePickerDirective


function DatePickerLinkFunction(scope, element, attr, ctrl, transcludeFn) {
    
}

function DatePickerController($scope, $element, $attrs, $transclude, DatePickerService) {
    $scope.CurrentYearIndex = null;
    $scope.CurrentMonthIndex = null;
    //$scope.SelectedDate = null;
    $scope.CurrentMonthName = null;
    $scope.CurrentYear = null;
    $scope.PanelVisible = false;

    //$watch section
    $scope.$watch('model', function (newValue, oldValue) {
        if($scope.model == null) return;
        var new_date = new Date($scope.model);
        $scope.SelectedDateText = DatePickerService.GetDateString(new_date);
        $scope.CurrentMonthName = DatePickerService.GetMonthNameByNumber(new_date.getMonth());
        $scope.CurrentYear = new_date.getFullYear();
        $scope.SelectedDate = new_date;
        $scope.CurrentMonthIndex = DatePickerService.GetMonthIndexByDate(new_date);
    });
    //end-of $watch section

    $scope.SetSelectedDate = function (Date) {
        $scope.model = Date;
    }

    $scope.IsToday = function (Day) {
        var support_date = new Date();
        if (Day.DayNumber == support_date.getDate()) {
            if (Day.MonthNumber == support_date.getMonth()) {
                if (Day.YearNumber == support_date.getFullYear()) {
                    return true;
                }
            }
        }
        //else:
        return false;
    }

    $scope.IsSelected = function (Day) {
        if ($scope.SelectedDate != null) {
            if (Day.DayNumber == $scope.SelectedDate.getDate()) {
                if (Day.MonthNumber == $scope.SelectedDate.getMonth()) {
                    if (Day.YearNumber == $scope.SelectedDate.getFullYear()) {
                        return true;
                    }
                }
            }
        }
        //else:
        return false;
    }

    $scope.TextInputChanged = function () {
        var picked_date = DatePickerService.StringToDate($scope.SelectedDateText);
        if (picked_date == undefined) {
            $scope.SelectedDateText = ""; //Jeśli kotś wpisał złą datę ale jest już jakaś data wybrana to co wtedy?
            //Nie powinna się wtedy data wybrana kasować? Jeśli powinna to trzeba ustawić jeszcze odpowiedni obiekt
            //typu Day w tablicy miesięcy (IsSelected = false).
        }
        $scope.SetSelectedDate(picked_date);
        //$scope.CurrentMonthIndex = DatePickerService.GetMonthIndexByDate(picked_date);
    }

    $scope.OnMonthChangeUpdate = function () {
        var tmp_date = new Date();
        tmp_date.setMonth($scope.CurrentMonthIndex);
        $scope.CurrentMonthName = DatePickerService.GetMonthNameByNumber(tmp_date.getMonth());
        $scope.CurrentYear = tmp_date.getFullYear();
        $scope.WeeksArray = DatePickerService.GetMonth($scope.CurrentMonthIndex);
    }

    $scope.PrevMonth = function () {
        $scope.CurrentMonthIndex = $scope.CurrentMonthIndex - 1;
        $scope.OnMonthChangeUpdate();
    }

    $scope.NextMonth = function () {
        $scope.CurrentMonthIndex = $scope.CurrentMonthIndex + 1;
        $scope.OnMonthChangeUpdate();
    }

    $scope.Open_Click = function () {
        if ($scope.SelectedDate == null) {
            var today = new Date();
            $scope.CurrentMonthIndex = today.getMonth();
            $scope.CurrentYear = today.getFullYear();
            $scope.CurrentMonthName = DatePickerService.GetMonthNameByNumber($scope.CurrentMonthIndex);
            $scope.WeeksArray = DatePickerService.GetMonth($scope.CurrentMonthIndex);
        } else {
            $scope.OnMonthChangeUpdate();
        }
       
        
        //var css_obj = {
        //    'display': 'block'
        //}
        //$element.find('div.datepicker-panel').css(css_obj);
        $scope.PanelVisible = true;
    }//end-of-Open_Click

    $scope.Close_Click = function () {
        //var v_scope = $scope;
        //var v_element = $element;
        //var v_attrs = $attrs;
        //var v_transclude = $transclude;

        $scope.PanelVisible = false;
        //var css_obj = {
        //    'display': 'none'
        //}
        //$element.find('div.datepicker-panel').css(css_obj);
    }//end-of-Close_Click

    $scope.SetDate = function (Day) {
        var selected_date = new Date();
        selected_date.setFullYear(Day.YearNumber);
        selected_date.setMonth(Day.MonthNumber);
        selected_date.setDate(Day.DayNumber);
        $scope.SetSelectedDate(selected_date);
    }//end-of-SetDate

}//end-of-DatePickerController

