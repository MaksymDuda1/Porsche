import { BodyType } from "../enums/BodyType";

export class SeaarchByConditionalsModel{
    model: string = '';
    bodyType: BodyType = 0;
    minYearOfRelease: number = 0;
    maxYearOfRelease: number = 0;
    engine: string = '';
    minPrice: number = 0;
    maxPrice: number = 0;
    porscheCenter: string = '';
}