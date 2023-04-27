enum AvatarVariants {
	Round,
	Rounded,
	Square,
}

type AvatarVariant = Lowercase<keyof typeof AvatarVariants>;

export type { AvatarVariant };
