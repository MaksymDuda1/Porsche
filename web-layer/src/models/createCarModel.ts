import { BodyType } from "../enums/BodyType";
import { Color } from "../enums/Color";
import { PhotoModel } from "./photoModel";

export class CreateCarModel{
    identityCode: string = '';
    model: string = '';
    yearOfEdition: number = 0;
    bodyType: BodyType = 0;
    color: Color = 0;
    engine: string = "";
    fuelConsumption: number = 0.0;
    price: number = 0.0;
    porscheCenterId: string = '';
    photos: File[] | null = [];
}