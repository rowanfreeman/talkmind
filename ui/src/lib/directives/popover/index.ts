import type { Action } from 'svelte/action';
import {
	computePosition,
	autoUpdate,
	flip,
	shift,
	offset,
	type Placement,
	type ComputePositionConfig,
} from '@floating-ui/dom';

interface PopoverProps {
	ref?: HTMLElement;
	placement?: Placement;
}

interface UpdatePosition {
	(ref: HTMLElement, tooltipRef: HTMLElement, options: ComputePositionConfig): void;
}

const updatePositionFactory = ((ref, tooltipRef, options) => () => {
	const updatePosition = async () => {
		const { x, y } = await computePosition(ref, tooltipRef, {
			...options,
			middleware: [flip(), shift(), offset(4)],
		});

		tooltipRef.style.left = `${x}px`;
		tooltipRef.style.top = `${y}px`;
	};

	updatePosition();
}) satisfies UpdatePosition;

const popover = ((node, params) => {
	let cleanup: (() => void) | undefined = undefined;

	if (!params?.ref) return;

	const { ref } = params;

	cleanup = autoUpdate(
		ref,
		node,
		updatePositionFactory(ref, node, { placement: params.placement }),
	);

	return {
		update: (params) => {
			popover(node, params);
		},
		cleanup: () => cleanup?.(),
	};
}) satisfies Action<HTMLElement, PopoverProps>;

export default popover;
