import type { Action } from 'svelte/action';

const scrollToBottomOnResize = ((node) => {
	const observer = new ResizeObserver((entries) => {
		const element = entries.at(0);

		element?.target?.scrollIntoView({ block: 'end' });
	});

	observer.observe(node);

	return {
		destroy: observer.disconnect,
	};
}) satisfies Action;

export default scrollToBottomOnResize;
