using System;

class Warrior
{
    private string _name { get; set; }
    public string Name { get=>_name;}
    private int _hp { get; set; }
    private int _maximumAttack { get; set; }
    private int _maximumBlock { get; set; }

    Random rnd = new Random();
    public Warrior(string name, int hp, int maximumAttack, int maximumBlock)
    {
        this._name = name;
        this._hp = hp;
        this._maximumAttack = maximumAttack;
        this._maximumBlock = maximumBlock;
    }
    
    public int Attack()
    {
        int damage = rnd.Next(1, _maximumAttack);
        return damage;
    }
    public int Block()
    {
        int block = rnd.Next(1, _maximumBlock);
        return block;
    }
    public int Hurt(int damage)
    {
        this._hp = this._hp - damage;
        if (this._hp <= 0)
        {
            this._hp = 0;
        }
        return this._hp;
    }


}
