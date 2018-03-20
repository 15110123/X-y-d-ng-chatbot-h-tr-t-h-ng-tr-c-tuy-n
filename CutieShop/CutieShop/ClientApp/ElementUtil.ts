export default class ElementUtil {
    static addScript(jsFile: string) {
        const element = document.createElement("script");
        element.src = `js/${jsFile}?v=` + this.guid();
        document.body.appendChild(element);
    }

    static guid() {
        //No symbol guid, reference: https://stackoverflow.com/questions/105034/create-guid-uuid-in-javascript
        return this.s4() + this.s4() + this.s4() + this.s4() + this.s4() + + this.s4() + this.s4() + this.s4();
    }

    private static s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }
}