enum ButtonVariants {
	Ghost,
	Filled,
	Outline,
	Text,
}

type ButtonVariant = Lowercase<keyof typeof ButtonVariants>;

export type { ButtonVariant };
