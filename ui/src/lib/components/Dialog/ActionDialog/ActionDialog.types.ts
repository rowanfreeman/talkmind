import type { ButtonProps } from '$lib/components/Button';

interface ActionDialogContext<TResult> {
	close: (result: TResult) => void;
	cancel: () => void;
}

interface OnClick<TResult> {
	(context: ActionDialogContext<TResult>): Promise<
		| ReturnType<ActionDialogContext<TResult>['cancel']>
		| ReturnType<ActionDialogContext<TResult>['close']>
	>;
}

export interface ButtonDescriptor<TResult> extends ButtonProps {
	content?: string;
	onClick?: OnClick<TResult>;
}
