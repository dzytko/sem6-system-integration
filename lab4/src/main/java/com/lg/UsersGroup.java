package com.lg;

import jakarta.persistence.*;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "user_groups")
public class UsersGroup {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    Long id;

    @ManyToMany(cascade = CascadeType.ALL)
    List<User> users = new ArrayList<>();

    public UsersGroup() {
    }

    public UsersGroup(Long id) {
        this.id = id;
    }

    public void addUser(User user) {
        users.add(user);
        user.getGroups().add(this);
    }

    public List<User> getUsers() {
        return users;
    }

    public void setUsers(List<User> users) {
        this.users = users;
    }
}
