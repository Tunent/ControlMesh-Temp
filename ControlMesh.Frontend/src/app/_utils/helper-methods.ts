export class HelperMethods {
    objectKeys(obj: any): string[] {
        return Object.keys(obj);
    }

    objectValue(obj: any, property: string) {
        return obj[property];
    }
}