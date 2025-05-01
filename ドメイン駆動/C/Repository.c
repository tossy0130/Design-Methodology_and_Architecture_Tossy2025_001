/*
■Repository（リポジトリ）

集約ルートの永続化を担当するインターフェース。データベース操作を隠蔽する。

*/

#define MAX_USERS 10

typedef struct {
    User users[MAX_USERS];
    int count;
} UserRepository;

void save_user(UserRepository* repo, User user) {
    if(repo->count < MAX_USERS) {
        repo->users[repo->count++] = user;
    }
}

User* find_user_by_id(UserRepository* repo, int id) {
    for (int i = 0; i < repo->count; i++) {
        if(repo->users[i].id == id) {
            return &repo->users[i];
        }
    }
    return NULL;
}