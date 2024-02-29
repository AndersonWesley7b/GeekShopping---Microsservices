namespace GeekShoppingMessageBus;
public interface IMessageBus
{
    Task PublicMessage(BaseMessage message, string queueName);
}
