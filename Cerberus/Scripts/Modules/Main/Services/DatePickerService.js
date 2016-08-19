var DatePickerService = function () {
    var _date = new Date();

    var _month_table = null;

    var _month_names_table = ['styczeń', 'luty', 'marzec', 'kwiecień', 'maj', 'czerwiec',
            'lipiec', 'sierpień', 'wrzesień', 'październik', 'listopad', 'grudzień'];

    var _init_current_month_day = function (DayNumber, MonthNumber, YearNumber) {
        var DayObj = new Object();
        DayObj.DayNumber = DayNumber;
        DayObj.MonthNumber = MonthNumber;
        DayObj.YearNumber = YearNumber;
        DayObj.IsOtherMonth = false;
        DayObj.IsCurrentMonth = true;
        DayObj.IsToday = false;
        return DayObj;
    }//end-of-_init_current_month_day

    var _init_other_month_day = function (DayNumber, MonthNumber, YearNumber) {
        var DayObj = new Object();
        DayObj.DayNumber = DayNumber;
        DayObj.MonthNumber = MonthNumber;
        DayObj.YearNumber = YearNumber;
        DayObj.IsOtherMonth = true;
        DayObj.IsCurrentMonth = false;
        DayObj.IsToday = false;
        return DayObj;
    }//end-of-_init_other_month_object

    var _StringToDate = function (DateString) {
        var split_table = DateString.split('.');
        var day = parseInt(split_table[0]);
        var month = parseInt(split_table[1]);
        var year = parseInt(split_table[2]);

        if (isNaN(day) || isNaN(month) || isNaN(year)) {
            return undefined;
        }

        var picked_date = new Date();
        picked_date.setFullYear(year);
        picked_date.setMonth(month - 1);
        picked_date.setDate(day);
        if ((picked_date.getFullYear() != year) || (picked_date.getMonth() != (month - 1)) || (picked_date.getDate() != day)) {
            return undefined;
        }

        return picked_date;
    }//end-of-_StringToDate

    var _init_month = function (MonthIndex) {
        if (MonthIndex == undefined) {
            MonthIndex = (new Date()).getMonth();
        }

        var starting_date = new Date();
        starting_date.setMonth(MonthIndex);
        var support_date = new Date();
        var active_month_array = new Array();
        var prev_month_array = new Array();
        var next_month_array = new Array();
        var join_array = new Array();
        var final_array = new Array();


        support_date.setMonth(MonthIndex);
        support_date.setDate(1);
        do {
            active_month_array.push(support_date.getDate());
            support_date.setDate(support_date.getDate() + 1);
        } while (support_date.getDate() != 1);

        support_date = new Date();
        support_date.setMonth(MonthIndex);
        support_date.setDate(1);
        support_date.setDate(support_date.getDate() - 1);
        while (support_date.getDay() != 0) {
            prev_month_array.unshift(support_date.getDate());
            support_date.setDate(support_date.getDate() - 1);
        }

        support_date = new Date();
        support_date.setMonth(MonthIndex);
        support_date.setDate(active_month_array[active_month_array.length - 1]);
        support_date.setDate(support_date.getDate() + 1);
        while (support_date.getDay() != 1) {
            next_month_array.push(support_date.getDate());
            support_date.setDate(support_date.getDate() + 1);
        }

        var support_array = new Array();
        support_date = new Date();
        support_date.setMonth(MonthIndex - 1);
        for (var i = 0; i < prev_month_array.length; i++) {
            support_array.push(_init_other_month_day(prev_month_array[i], support_date.getMonth(), support_date.getFullYear()));
        }
        support_date = new Date();
        support_date.setMonth(MonthIndex);
        for (var i = 0; i < active_month_array.length; i++) {
            support_array.push(_init_current_month_day(active_month_array[i], support_date.getMonth(), support_date.getFullYear()));
        }
        support_date = new Date();
        support_date.setMonth(MonthIndex + 1);
        for (var i = 0; i < next_month_array.length; i++) {
            support_array.push(_init_other_month_day(next_month_array[i], support_date.getMonth(), support_date.getFullYear()));
        }

        i = 0;
        while (i < support_array.length) {
            var single_week_array = new Array();
            for (var j = 0; j < 7; j++) {
                single_week_array.push(support_array[i++]);
            }
            final_array.push(single_week_array);
        }

        return final_array;
    }//end-of-_init_month

    _GetMonth = function (MonthIndex) {
        if (_month_table == null) {
            _month_table = new Array();
        }
        if (_month_table[MonthIndex] == undefined) {
            _month_table[MonthIndex] = _init_month(MonthIndex);
        }
        return _month_table[MonthIndex];
    }

    var _GetMonthIndexByDate = function (SelectedDate) {
        var support_date = new Date();
        var year = support_date.getFullYear();
        var month = support_date;
        var current_month_index = support_date.getMonth();
        var incrementer;
        if (SelectedDate < support_date) {
            incrementer = -1;
        } else {
            incrementer = 1;
        }

        while ((support_date.getFullYear() != SelectedDate.getFullYear()) || (support_date.getMonth() != SelectedDate.getMonth())) {
            current_month_index += incrementer;
            support_date = new Date();
            support_date.setMonth(current_month_index);
        }
        return current_month_index;
    }

    var _GetMonthNameByNumber = function (MonthNumber) {
        return _month_names_table[MonthNumber];
    }

    var _GetDateString = function (Date) {
        var result_string = "";
        result_string += ('0' + Date.getDate()).slice(-2);
        result_string += ".";
        result_string += ('0' + (Date.getMonth() + 1)).slice(-2);
        result_string += ".";
        result_string += Date.getFullYear().toString();
        return result_string;
    }


    return {
        GetDate: _date,
        StringToDate: _StringToDate,
        GetMonth: _GetMonth,
        GetMonthIndexByDate: _GetMonthIndexByDate,
        GetMonthNameByNumber: _GetMonthNameByNumber,
        GetDateString: _GetDateString
    }//end-of-DatePickerService-return
};