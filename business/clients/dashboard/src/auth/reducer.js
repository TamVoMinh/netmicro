const INITIAL_STATE = {
    user: {
        id: 1,
        name: 'Duong Nguyen',
        email: 'phuduong290392@gmail.com',
        imageUrl:
            'https://i7.pngguru.com/preview/266/82/468/programmer-computer-icons-computer-programming-avatar-programming-language-avatar-thumbnail.jpg'
    }
};

export default function Auth(state = INITIAL_STATE, action) {
    switch (action.type) {
        default:
            return state;
    }
}
