export enum Color
{
    Red,
    Blue,
    Green,
    Gray,
    White,
    Yellow,
    Black  
}

export function colorToString(color: Color): string {
    switch (color) {
        case Color.Red:
            return "Red";
        case Color.Blue:
            return "Blue";
        case Color.Green:
            return "Green";
        case Color.Gray:
            return "Gray";
        case Color.White:
            return "White";
        case Color.Yellow:
            return "Yellow";
        case Color.Black:
            return "Black";
        default:
            throw new Error("Invalid color");
    }
}

export function stringToColor(colorString: string): Color {
    switch (colorString) {
        case "Red":
            return Color.Red;
        case "Blue":
            return Color.Blue;
        case "Green":
            return Color.Green;
        case "Gray":
            return Color.Gray;
        case "White":
            return Color.White;
        case "Yellow":
            return Color.Yellow;
        case "Black":
            return Color.Black;
        default:
            throw new Error("Invalid color string");
    }
}