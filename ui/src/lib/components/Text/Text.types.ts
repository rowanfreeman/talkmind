enum TextSizes {
	xs,
	sm,
	base,
	lg,
	xl,
	'2xl',
	'3xl',
	'4xl',
	'5xl',
	'6xl',
	'7xl',
	'8xl',
	'9xl',
}

type TextSize = Lowercase<keyof typeof TextSizes>;

export type { TextSize, TextSizes };
