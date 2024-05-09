
export enum BodyType
{
    Coupe,
    Sedan, 
    Suv,
    Cabriolet
}

export function bodyTypeToString(bodyType: BodyType): string {
    switch (bodyType) {
        case BodyType.Coupe:
            return "Coupe";
        case BodyType.Sedan:
            return "Sedan";
        case BodyType.Suv:
            return "SUV";
        case BodyType.Cabriolet:
            return "Cabriolet";
        default:
            throw new Error("Invalid body type");
    }
}

export function stringToBodyType(bodyTypeString: string): BodyType {
    switch (bodyTypeString) {
        case "Coupe":
            return BodyType.Coupe;
        case "Sedan":
            return BodyType.Sedan;
        case "SUV":
            return BodyType.Suv;
        case "Cabriolet":
            return BodyType.Cabriolet;
        default:
            throw new Error("Invalid body type string");
    }
}