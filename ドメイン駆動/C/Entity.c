/*

■ Entity（エンティティ）

識別子によって区別され、ライフサイクル全体にわたって一貫性を保つオブジェクト。
例：ユーザー、注文など。
*/

typedef struct {
    int id;
    char name[100];
} User;

void rename_user(User* user, const char* new_name) {
    strncpy(user->name, new_name, sizeof(user->name) - 1);
    user->name[sizeof(user->name) - 1] = '\0';
}



