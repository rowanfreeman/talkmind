import type { Action } from 'svelte/action';

enum Methods {
	Append,
	Insert,
}

type Method = Lowercase<keyof typeof Methods>;

interface TeleportProps {
	/** A query selector */
	target: string;
	/** Append at the end of the target or insert at the beginning */
	method?: Method;
}

const teleport: Action<HTMLElement, TeleportProps> = (node, params) => {
	const perform = (params?: TeleportProps) => {
		if (!params?.target) return;
		const target = node.ownerDocument.querySelector(params.target);

		params.method === 'insert'
			? target?.insertBefore(node, target.firstChild)
			: target?.appendChild(node);
	};

	perform(params);

	return {
		update: perform,
	};
};

export default teleport;
