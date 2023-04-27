interface Party {
	id: string;
	name: string;
}

type Occupants = [Party, Party];

type Content = string;
type MessageId = string;

interface Message {
	content: Content;
	id: MessageId;
	key: string;
	partyId: Party['id'];
	pending?: boolean;
	timestamp: Date;
}

type Dialog = Message[];

export type { Dialog, Message, MessageId, Occupants, Party, Content };
