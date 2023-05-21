import type { IconType } from '$lib/components/Icon';

export interface TextInputProps {
	description?: string;
	dirty?: boolean;
	disabled?: boolean;
	error?: string;
	iconLeft?: IconType;
	iconRight?: IconType;
	id?: string;
	label?: string;
	maxlength?: number;
	minlength?: number;
	placeholder?: string;
	readonly?: boolean;
	required?: boolean;
	type?: InputType;
	value?: string;
}

enum InputTypes {
	Text,
	Password,
	Email,
}

type InputType = Lowercase<keyof typeof InputTypes>;

export { type InputType, InputTypes };
