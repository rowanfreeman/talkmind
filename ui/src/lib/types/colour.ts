export enum Colours {
	Amber,
	Blue,
	Cyan,
	Emerald,
	Fuchsia,
	Green,
	Indigo,
	Lime,
	Orange,
	Pink,
	Purple,
	Red,
	Rose,
	Sky,
	Teal,
	Violet,
	Yellow,
}

type Colour = Lowercase<keyof typeof Colours>;

export type { Colour };
