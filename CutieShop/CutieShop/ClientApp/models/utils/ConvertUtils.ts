export class DateConvertUtils {
    static dateToyyyyMMdd(date: Date, separator:string) {
        let mm = (date.getMonth() + 1).toString();
        if (date.getMonth() < 9) mm = `0${mm}`;

        let dd = date.getDate().toString();
        if (date.getDate() < 10) dd = `0${dd}`;

        return date.getFullYear() + separator + mm + separator + dd;
    }

    static dateToddMMyyyy(date: Date, separator: string) {
        let mm = (date.getMonth() + 1).toString();
        if (date.getMonth() < 9) mm = `0${mm}`;

        let dd = date.getDate().toString();
        if (date.getDate() < 10) dd = `0${dd}`;

        return dd + separator + mm + separator + date.getFullYear();
    }
}

export class NumberConvertUtil {
    static numberToPrice(value: number, unit: string) {
        let strValue = value.toString();
        let strValueWithSep = "";
        for (var i = strValue.length - 1; i >= 0; i--) {
            strValueWithSep = strValue[i] + strValueWithSep;
            if (i % 3 === 0 && i != 0) {
                strValueWithSep = "," + strValueWithSep;
            }
        }
        return strValueWithSep + " " + unit;
    }
}