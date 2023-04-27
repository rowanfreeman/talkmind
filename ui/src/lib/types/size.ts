enum CommonSizes {
	xs,
	sm,
	md,
	lg,
	xl,
}

type CommonSize = Lowercase<keyof typeof CommonSizes>;

export type { CommonSize };
