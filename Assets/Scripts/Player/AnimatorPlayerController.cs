public static class AnimatorPlayerController
{
    public static class Params
    {
        public const string Speed = nameof(Speed);
        public const string Jump = nameof(Jump);
        public const string IsOnGround = nameof(IsOnGround);
        public const string TakeDamage = nameof(TakeDamage);
        public const string IsDeath = nameof(IsDeath);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Run = nameof(Run);
        public const string Jump = nameof(Jump);
        public const string TakeDamage = nameof(TakeDamage);
        public const string Death = nameof(Death);
    }
}
