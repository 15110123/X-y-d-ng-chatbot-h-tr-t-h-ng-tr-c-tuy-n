//ReSharper disable All

export class GETParameterUtils {
    static getValue(key: string) {
        return (new URLSearchParams(window.location.search)).get(key);
    }
}