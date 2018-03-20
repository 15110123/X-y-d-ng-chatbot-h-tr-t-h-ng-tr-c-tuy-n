export default class ConvertUtil {
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