import type { ComponentType } from 'svelte';
import { writable } from 'svelte/store';

interface DialogDescriptor {
	component: ComponentType;
	props: Record<string, unknown>;
	resolve: <TResult>(value: TResult) => void;
}

const dialogs = new Map<Symbol, DialogDescriptor>();

const dialogStore = writable(dialogs);

export default dialogStore;
