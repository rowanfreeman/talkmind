import type { ComponentEvents, ComponentProps, ComponentType, SvelteComponent } from 'svelte';
import dialogStore from '$lib/components/Dialog/stores/dialogStore';

type DialogClosedEventReturnType<TDialog extends SvelteComponent> =
	ComponentEvents<TDialog> extends { closed: infer TReturn } ? TReturn : never;

interface OpenDialog {
	<TDialog extends SvelteComponent>(dialog: ComponentType, props: ComponentProps<TDialog>): Promise<
		DialogClosedEventReturnType<TDialog>
	>;
}

interface DialogManager {
	open: OpenDialog;
}

const dialogManager: DialogManager = {
	open: async <TDialog extends SvelteComponent>(
		dialog: ComponentType,
		props: ComponentProps<TDialog>,
	) => {
		const symbol = Symbol();

		const promise = new Promise<DialogClosedEventReturnType<TDialog>>((resolve) => {
			dialogStore.update((x) =>
				x.set(symbol, {
					component: dialog,
					props: { ...props, open: true },
					resolve: (value) => resolve(value as DialogClosedEventReturnType<TDialog>),
				}),
			);
		});

		const result = await promise;

		return result;
	},
};

export default dialogManager;
