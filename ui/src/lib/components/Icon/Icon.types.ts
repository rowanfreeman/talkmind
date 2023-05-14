import * as heroicons from '@steeze-ui/heroicons';

type Icon = keyof typeof heroicons;

export type { Icon };
export const icons = Object.keys(heroicons) as Icon[];
