/*

■Value Object（値オブジェクト）

Cではイミュータブルは保証できないが、readonly的な使い方は可能。

*/

typedef struct {
    char email[100];

} Email;

int is_valid_email(const Email* email) {
    return strchr(email->email, '@') != NULL;
}