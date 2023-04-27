enum Colours {
	Red,
	Orange,
	Amber,
	Yellow,
	Lime,
	Green,
	Emerald,
	Teal,
	Cyan,
	Sky,
	Blue,
	Indigo,
	Violet,
	Purple,
	Fuchsia,
	Pink,
	Rose,
}

type Colour = Lowercase<keyof typeof Colours>;

export default Colour;
