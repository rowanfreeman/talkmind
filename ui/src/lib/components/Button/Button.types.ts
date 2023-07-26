import type { Placement } from '@floating-ui/dom';

import type { CommonSize } from '$lib/types/size';
import type { Colour } from '$lib/types/colour';
import type { IconType } from '$lib/components/Icon';

interface TooltipOptions {
	content: string;
	placement?: Placement;
}

interface ButtonProps {
	class?: string;
	colour?: Colour;
	disabled?: boolean;
	iconLeft?: IconType;
	iconRight?: IconType;
	loading?: boolean;
	round?: boolean;
	size?: CommonSize;
	tooltip?: TooltipOptions;
	variant?: ButtonVariant;
}

enum ButtonVariants {
	Ghost,
	Filled,
	Outline,
	Text,
}

type ButtonVariant = Lowercase<keyof typeof ButtonVariants>;

export { type ButtonVariant, ButtonVariants, type ButtonProps };
