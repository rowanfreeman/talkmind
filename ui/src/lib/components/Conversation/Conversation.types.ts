interface Party {
	id: string;
	name: string;
}

type Occupants = [Party, Party];

type Content = string | Promise<string>;
type MessageId = string;

interface Message {
	content: Content;
	id: MessageId;
	key: string;
	partyId: Party['id'];
	timestamp: Date;
}

type Dialog = Message[];

export type { Dialog, Message, MessageId, Occupants, Party, Content };
